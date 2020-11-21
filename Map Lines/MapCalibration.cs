using KEUtils.Utils;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace MapLines {
    public class MapCalibration {
        public static readonly String NL = Environment.NewLine;
        public List<MapData> DataList { get; set; } = new List<MapData>();
        public MapTransform Transform { get; set; }
        public double Det { get; set; }

        public bool read(string fileName) {
            MapData data = null;
            bool ok = false;
            string[] tokens = null;
            try {
                foreach (string line in File.ReadAllLines(fileName)) {
                    int x, y;
                    double lon, lat;
                    tokens = Regex.Split(line.Trim(), @"\s+");
                    // Skip blank lines
                    if (tokens.Length == 0) {
                        continue;
                    }
                    // Skip lines starting with #
                    if (tokens[0].Trim().StartsWith("#")) {
                        continue;
                    }
                    x = Int32.Parse(tokens[0]);
                    y = Int32.Parse(tokens[1]);
                    lon = Double.Parse(tokens[2]);
                    lat = Double.Parse(tokens[3]);
                    // DEBUG
                    // System.out.println(string.format("x=%d y=%d lon=%.6f lat=%.6f",
                    // x,
                    // y, lon, lat));
                    data = new MapData(x, y, lon, lat);
                    DataList.Add(data);
                }
            } catch (Exception ex) {
                Utils.excMsg("Failed to read " + fileName, ex);
            }
            // Make the transform
            createTransform();
            return ok;
        }

        /// <summary>
        /// Calculates a, b, c, d, e, and f using singular value decomposition.
        ///     lon = a*x + b*y + e;
        ///     lat = c*x + d*y + f;
        /// </summary>
        protected void createTransform() {
            Transform = null;
            if (DataList.Count < 3) {
                Utils.errMsg("Need at least three data points for calibration.");
                return;
            }

            // Define the matrices
            MatrixBuilder<double> M = Matrix<double>.Build;
            VectorBuilder<double> V = Vector<double>.Build;
            int nPoints2 = 2 * DataList.Count;
            Matrix<double> aa = M.Dense(nPoints2, 6);
            Vector<double> bb = V.Dense(nPoints2);
            MapData data = null;
            int row;
            for (int i = 0; i < DataList.Count; i++) {
                data = DataList[i];
                row = 2 * i;
                aa[row, 0] = data.X;
                aa[row, 1] = data.Y;
                aa[row, 4] = 1;
                bb[row] = data.Lon;
                row++;
                aa[row, 2] = data.X;
                aa[row, 3] = data.Y;
                aa[row, 5] = 1;
                bb[row] = data.Lat;
            }

            // Get the singular values
            try {
                Svd<double> svd = aa.Svd(true);
                Matrix<double> u = svd.U;
                Matrix<double> vt = svd.VT;
                Matrix<double> w = svd.W;
                Matrix<double> wi = w.Clone();
                for (int i = 0; i < 6; i++) {
                    if (wi[i, i] != 0) wi[i, i] = 1.0 / wi[i, i];
                }
                Matrix<double> aainv = vt.Transpose() * wi.Transpose() * u.Transpose();
                Vector<double> xx = aainv * bb;
                double a = xx[0];
                double b = xx[1];
                double c = xx[2];
                double d = xx[3];
                double e = xx[4];
                double f = xx[5];
                Transform = new MapTransform(a, b, c, d, e, f);
            } catch (Exception ex) {
                Utils.excMsg("Failed to create calibration transform", ex);
                Transform = null;
            }
        }

        /// <summary>
        /// Transforms the pixel coordinates (x,y) to (longitude, latitude).
        /// Calculates the inverse each time, but is not that time-consuming
        /// to try to be more efficient.
        ///     lon = a*x + b*y + e;
        ///     lat = c*x + d*y + f;
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>{longitude, latitude}</returns>
        public double[] transform(int x, int y) {
            if (Transform == null) {
                return null;
            }
            double[] val = new double[2];
            val[0] = Transform.A * x + Transform.B * y + Transform.E;
            val[1] = Transform.C * x + Transform.D * y + Transform.F;
            // DEBUG
            // System.out.println(
            // string.format("x=%d y=%d lon=%.6f lat=%.6f", x, y, val[0], val[1]));
            return val;
        }

        /// <summary>
        /// Transforms (longitude, latitude) to pixel coordinates (x,y).
        /// </summary>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public Point inverse(double lon, double lat) {
            double det = Transform.Determinant;
            double v1, v2;
            lon -= Transform.E;
            lat -= Transform.F;
            v1 = Transform.D * lon - Transform.B * lat;
            v2 = Transform.A * lat - Transform.C * lon;
            v1 /= det;
            v2 /= det;
            return new Point((int)(v1 + .5), (int)(v2 + .5));
        }

        /// <summary>
        /// Simple string reprsentation of a matrix.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static public string matrixAsString(Matrix<double> m) {
            // string strVal = m.ToString();
            string info = "";
            double[,] d = m.AsArray();

            for (int row = 0; row < d.GetLength(0); row++) {
                for (int col = 0; col < d.GetLength(1); col++) {
                    info += $"m.get(row, col),6:N4" + "\t";
                }
                info += Utils.NL;
            }
            info += Utils.NL;
            return info;
        }

        /// <summary>
        /// Class that represents the pixel to lat/lon transform.
        /// </summary>
        public class MapTransform {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double D { get; set; }
            public double E { get; set; }
            public double F { get; set; }
            public double Determinant { get; set; }

            public MapTransform(double a, double b, double c, double d, double e, double f) {
                A = a;
                B = b;
                C = c;
                D = d;
                E = e;
                F = f;
                Determinant = A * D - B * C;
            }
        }

        /// <summary>
        /// Class that represents one line in a calibration file.
        /// </summary>
        public class MapData {
            public int X { get; set; }
            public int Y { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }

            public MapData(int x, int y, double lon, double lat) {
                X = x;
                Y = y;
                Lon = lon;
                Lat = lat;
            }
        }
    }
}
