//#define TEST

using KEUtils.InputDialog;
using KEUtils.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MapLines {
    public class Lines {
        public static readonly string START_LINES_TAG = "STARTLINE";
        public static readonly string END_LINES_TAG = "ENDLINE";
        public static readonly string UTC_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";
        public List<Line> LinesList { get; set; } = new List<Line>();

        /// <summary>
        /// The default speed to use for calculating time differences (mph).
        /// </summary>
        public static readonly double DEFAULT_SPEED = 10;

        public Lines() {
#if TEST
            lines.Add(new Line(
                        new int[,] { { 405, 5 }, { 406, 110 }, { 412, 204 },
                        { 420, 220 }, { 530, 220 }, { 5640, 330 } }));
            lines.Add(new Line(
                    new int[,] { { -30, 135 }, { 220, 10 }, { 216, 204 }, 
                    { 312, 320 }, { 415, 520 }, { 340, 630 } }));
            lines.Add(new Line(new int[,] { { 435, 307 }, { 456, 305 },
                { 522, 304 }, { 532, 320 }, { 618, 325 },
                    { 540, 550 } }));
#endif
        }

        /// <summary>
        /// Adds the given line.
        /// </summary>
        /// <param name="line"></param>
        public void addLine(Line line) {
            if (LinesList != null) {
                LinesList.Add(line);
            }
        }

        /// <summary>
        /// Removes the given line.
        /// </summary>
        /// <param name="line"></param>
        public void removeLine(Line line) {
            if (LinesList != null) {
                LinesList.Remove(line);
            }
        }

        /// <summary>
        /// Removes the line at index.
        /// </summary>
        /// <param name="index"></param>
        public void removeLine(int index) {
            if (LinesList != null) {
                LinesList.RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes all the lines.
        /// </summary>
        public void clear() {
            if (LinesList != null) {
                LinesList.Clear();
            }
        }

        /// <summary>
        /// Gets the number of lines.
        /// </summary>
        /// <returns></returns>
        public int NLines {
            get { return LinesList.Count; }
        }

        /// <summary>
        /// Saves the lines to a file.
        /// </summary>
        /// <param name="fileName"></param>
        public void saveLines(string fileName) {
            if (LinesList == null) return;
            Point point;
            try {
                using (StreamWriter outputFile = File.CreateText(fileName)) {
                    foreach (Line line in LinesList) {
                        if (line.Desc != null && line.Desc.Length != 0) {
                            outputFile.WriteLine(START_LINES_TAG + " " + line.Desc);
                        } else {
                            outputFile.WriteLine(START_LINES_TAG);
                        }
                        for (int j = 0; j < line.NPoints; j++) {
                            point = line.Points[j];
                            outputFile.WriteLine(point.X + " " + point.Y);
                        }
                        outputFile.WriteLine(END_LINES_TAG);
                    }
                }
            } catch (Exception ex) {
                Utils.excMsg("Error writing" + fileName, ex);
                return;
            }
        }

        /// <summary>
        /// Saves the lines to a CSV file. Same as saveLines without the tags
        /// and using a comma rather than a space as separator.
        /// </summary>
        /// <param name="fileName"></param>
        public void saveLinesCsv(string fileName) {
            if (LinesList == null) return;
            Point point;
            try {
                using (StreamWriter outputFile = File.CreateText(fileName)) {
                    foreach (Line line in LinesList) {
                        outputFile.WriteLine(line.Desc);
                        for (int j = 0; j < line.NPoints; j++) {
                            point = line.Points[j];
                            outputFile.WriteLine(point.X + "," + point.Y);
                        }
                    }
                }
            } catch (Exception ex) {
                Utils.excMsg("Error writing" + fileName, ex);
                return;
            }
        }

        public void writeGpxFile(String fileName, MapCalibration mapCalibration) {
            if (LinesList == null) return;
            // Prompt for start time and avg speed
            double speed = DEFAULT_SPEED;
            InputDialog dlg = new InputDialog("Write GPX",
                "Enter the average speed to use:", $"{DEFAULT_SPEED:N1}");
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK) {
                string val = dlg.Value;
                try {
                    speed = Convert.ToDouble(val);
                } catch (Exception ex) {
                    Utils.excMsg("Failed to get a valid speed, using "
                        + DEFAULT_SPEED + " mph", ex);
                }
            }
            DateTime startTime = DateTime.Now;
            dlg = new InputDialog("Write GPX",
                "Enter the local start time:", startTime.ToString());
            res = dlg.ShowDialog();
            if (res == DialogResult.OK) {
                string val = dlg.Value;
                try {
                    startTime = Convert.ToDateTime(val);
                } catch (Exception ex) {
                    Utils.excMsg("Failed to get a valid starttime, " +
                        "using the current time", ex);
                }
            }
            // Convert to UTC for writing the GPX file
            startTime = startTime.ToUniversalTime();
            DateTime newTime = startTime;
            Point point;
            try {
                using (StreamWriter outputFile = File.CreateText(fileName)) {
                    // Write header
                    outputFile.WriteLine(
                        "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>");
                    outputFile.WriteLine("<gpx");
                    outputFile.WriteLine(" creator=\"MapLines\"");
                    outputFile.WriteLine(" version=\"1.1\"");
                    outputFile.WriteLine(" xmlns=\"http://www.topografix.com/GPX/1/1\"");
                    outputFile.WriteLine(
                        " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
                    outputFile.WriteLine(
                        " xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 ");
                    outputFile.WriteLine("   http://www.topografix.com/GPX/1/1/gpx.xsd\">");

                    // Write metadata
                    outputFile.WriteLine("  <metadata>");
                    outputFile.WriteLine("    <time>" + startTime.ToString(UTC_FORMAT) + "</time>");
                    outputFile.WriteLine("  </metadata>");

                    // Write lines
                    outputFile.WriteLine("  <trk>");
                    outputFile.WriteLine("    <extensions>");
                    outputFile.WriteLine(
                        "      <gpxx:TrackExtension xmlns:gpxx=" +
                        "\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\">");
                    outputFile.WriteLine(
                        "        <gpxx:DisplayColor>Blue</gpxx:DisplayColor>");
                    outputFile.WriteLine("      </gpxx:TrackExtension>");
                    outputFile.WriteLine("    </extensions>");
                    double lon0 = 0, lat0 = 0;
                    double dist = 0;
                    double distTot = 0;
                    long time = 0;
                    foreach (Line line in LinesList) {
                        outputFile.WriteLine("    <trkseg>");
                        outputFile.WriteLine("      <name>" + line.Desc + "</name>");
                        for (int j = 0; j < line.NPoints; j++) {
                            point = line.Points[j];
                            double[] vals = mapCalibration.transform(point.X,
                                point.Y);
                            outputFile.WriteLine($"      <trkpt lat=\"{vals[1]:N6}\"" +
                                $" lon=\"{vals[0]:N6}\">");
                            outputFile.WriteLine("        <ele>0.0</ele>");
                            // Increment the time assuming a default speed
                            if (j == 0) {
                                lon0 = vals[0];
                                lat0 = vals[1];
                            } else {
                                dist = Math.Abs(Gps.M2MI *
                                    Gps.greatCircleDistance(lat0, lon0, vals[1], vals[0]));
                                time = (long)(dist / speed * 3600.0 * 1000.0);
                                newTime = newTime.AddMilliseconds(time);
                                lon0 = vals[0];
                                lat0 = vals[1];
                            }
                            distTot += dist;
                            outputFile.WriteLine("        <time>"
                                + newTime.ToString(UTC_FORMAT) + "</time>");
                            outputFile.WriteLine("      </trkpt>");
                        }
                        outputFile.WriteLine("    </trkseg>");
                    }
                    outputFile.WriteLine("  </trk>");
                    outputFile.WriteLine("</gpx>");
                }
            } catch (Exception ex) {
                Utils.excMsg("Error writing" + fileName, ex);
                return;
            }
        }

        /// <summary>
        /// Reads lines from a file and adds them to the current lines.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool readLines(string fileName) {
            bool ok = false;
            string[] tokens;
            Line line = null;
            int lineNum = 0;
            try {
                foreach (string fileLine in File.ReadAllLines(fileName)) {
                    lineNum++;
                    tokens = Regex.Split(fileLine, @"\s+");
                    // Skip blank lines
                    if (tokens.Length == 0) {
                        continue;
                    }
                    // Skip lines starting with #
                    if (tokens[0].Trim().StartsWith("#")) {
                        continue;
                    }
                    if (tokens[0].Equals(START_LINES_TAG)) {
                        line = new Line();
                        int end1 = START_LINES_TAG.Length;
                        int end2 = fileLine.Length;
                        if (end2 > end1) {
                            line.Desc = fileLine.Substring(end1).Trim();
                        }
                        continue;
                    }
                    if (tokens[0].Equals(END_LINES_TAG)) {
                        if (line != null) {
                            addLine(line);
                            line = null;
                        }
                        continue;
                    }
                    // Must be 2 or more values, any after 2 are ignored
                    if (tokens.Length < 2) {
                        Utils.errMsg("Invalid Lines file at line " + lineNum);
                        return false;
                    }
                    int x = Int32.Parse(tokens[0]);
                    int y = Int32.Parse(tokens[1]);
                    line.addPoint(new Point(x, y));
                }
            } catch (Exception ex) {
                Utils.excMsg("Failed to read " + fileName, ex);
            }
            return ok;
        }



        /// <summary>
        /// Reads lines from a GPX file and adds them to the current lines.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="mapCalibration"></param>
        /// <returns>The number of trackpoints read.</returns>
        public int readGpxLines(string fileName, MapCalibration mapCalibration) {
            XDocument document = XDocument.Load(fileName);
            XElement root = document.Root;
            int nTrkPoints = 0, nTrkSeg = 0;
            double lat, lon;
            string strVal;
            Point point;
            Line line = null;
            try {
                foreach (XElement elemSeg in from item in root.Descendants().
                        Where(elemSeg => elemSeg.Name.LocalName == "trkseg")
                                             select item) {
                    if (elemSeg.Name.LocalName == "trkseg") {
                        nTrkSeg++;
                        line = new Line();
                        line.Desc = "Seg " + nTrkSeg + " from " + fileName;
                        foreach (XElement elemTkpt in from item in elemSeg.Descendants().
                            Where(elemSeg => elemSeg.Name.LocalName == "trkpt")
                                                      select item) {
                            nTrkPoints++;
                            strVal = elemTkpt.Attribute("lat").Value;
                            lat = Double.Parse(strVal);
                            strVal = elemTkpt.Attribute("lon").Value;
                            lon = Double.Parse(strVal);
                            point = mapCalibration.inverse(lon, lat);
                            line.addPoint(point);
                        }
                    }
                    if (line != null && line.NPoints > 0) addLine(line);
                }
            } catch (Exception ex) {
                Utils.excMsg("Error reading GPX lines", ex);
            }
            return nTrkPoints;
        }

        /// <summary>
        /// Gives info about the current Lines.
        /// </summary>
        public string info() {
            string NL = Utils.NL;
            string info = "";
            // info += this.toString() + LS;
            info += "nLines=" + NLines + NL;
            Line line;
            for (int i = 0; i < NLines; i++) {
                line = LinesList[i];
                info += "  Line " + i + " nPoints=" + line.NPoints
                    + " " + line + NL;
            }
            return info;
        }
    }

    public class Gps {
        // GPS Constants

        /// <summary>
        /// Nominal radius of the earth in miles. The radius actually varies from
        ///  3937 to 3976 mi.
        /// </summary>
        public const double REARTH = 3956;
        /// <summary>
        /// Multiplier to convert miles to nautical miles.
        /// </summary>
        public const double MI2NMI = 1.852; // Exact
        /// <summary>
        /// Multiplier to convert degrees to radians.
        /// </summary>
        public const double DEG2RAD = Math.PI / 180.0;
        /// <summary>
        /// Multiplier to convert feet to miles.
        /// </summary>
        public const double FT2MI = 1.0 / 5280.0;
        /// <summary>
        /// Multiplier to convert meters to miles.
        /// </summary>
        public const double M2MI = .00062137119224;
        /// <summary>
        /// Multiplier to convert kilometers to miles.
        /// </summary>
        public const double KM2MI = .001 * M2MI;
        /// <summary>
        /// Multiplier to convert meters to feet.
        /// </summary>
        public const double M2FT = 3.280839895;
        /// <summary>
        /// Multiplier to convert sec to hours.
        /// </summary>
        public const double SEC2HR = 1.0 / 3600.0;
        /// <summary>
        /// Multiplier to convert millisec to hours.
        /// </summary>
        public const double MS2HR = .001 * SEC2HR;

        /// <summary>
        /// Returns great circle distance in meters. assuming a spherical earth.
        /// Uses Haversine formula.
        /// </summary>
        /// <param name="lat1">Start latitude in deg.</param>
        /// <param name="lon1">Start longitude in deg.</param>
        /// <param name="lat2">End latitude in deg.</param>
        /// <param name="lon2">End longitude in deg.</param>
        /// <returns></returns>
        public static double greatCircleDistance(double lat1, double lon1,
            double lat2, double lon2) {
            double slon, slat, a, c, d;

            // Convert to radians
            lat1 *= DEG2RAD;
            lon1 *= DEG2RAD;
            lat2 *= DEG2RAD;
            lon2 *= DEG2RAD;

            // Haversine formula
            slon = Math.Sin((lon2 - lon1) / 2.0);
            slat = Math.Sin((lat2 - lat1) / 2.0);
            a = slat * slat + Math.Cos(lat1) * Math.Cos(lat2) * slon * slon;
            c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            d = REARTH / M2MI * c;

            return (d);
        }
    }
}
