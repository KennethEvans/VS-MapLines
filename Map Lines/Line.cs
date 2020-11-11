using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MapLines {
    public class Line {
        public static readonly Color DEFAULT_LINE_COLOR = Color.Red;
        public Color Color { get; set; } = DEFAULT_LINE_COLOR;
        public List<Point> Points { get; set; } = new List<Point>();
        public String Desc { get; set; } = "";
        /// <summary>
        /// The number of points in the Line.
        /// </summary>
        public int NPoints {
            get { return Points.Count; }
        }


        public Line(int[,] data) {
            if (data == null || data.Length == 0) {
                return;
            }
            if (data.GetLength(0) != 1 || data.GetLength(1) != 2) {
                Utils.errMsg("Data array must be an array of sets of two integers");
                return;
            }
            for (int i = 0; i < data.GetUpperBound(0); i++) {
                Points.Add(new Point(data[i, 0], data[i, 1]));
            }
        }

        public override string ToString() {
            if (String.IsNullOrEmpty(Desc)) return "<no name>";
            return Desc;
        }

        public Line() {
            // Do nothing
        }

        public Line(Color color) {
            this.Color = color;
        }

        public void addPoint(Point point) {
            if (Points != null) {
                Points.Add(point);
            }
        }

        public void removePoint(Point point) {
            if (Points != null) {
                Points.Remove(point);
            }
        }

        public void removePoint(int index) {
            if (Points != null) {
                Points.RemoveAt(index);
            }
        }

        /// <summary>
        /// Deletes the last point of the line if there is one.
        /// </summary>
        public void deleteLastPoint() {
            int nPoints = Points.Count;
            if (nPoints > 0) {
                Points.RemoveAt(nPoints - 1);
            }
        }
    }
}
