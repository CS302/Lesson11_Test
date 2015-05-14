using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson10_Ser
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Point p1 = new Point(10, 15);
            p1.label = "Первая точка";

            BinarySerialization(p1);
             * 
            Point p = BinaryDeSerialization();
            p.Print();*/
            /*Point p1 = new Point(10, 15);
            p1.label = "Первая точка";

            XmlSerialization(p1);

            Point p = XmlDeSerialization();
            p.Print();*/

            Random rnd = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < rnd.Next(5, 100); i++)
            {
                Point p = new Point(rnd.Next(-100, 101), rnd.Next(-100, 101));
                p.label = "label " + i;
                points.Add(p);
            }

            //XmlSerialization(points);
            List<Point> ps = XmlDeSerialization();
            for (int i = 0; i < ps.Count; i++)
            {
                ps[i].Print();
                Console.WriteLine();
            }
        }

        private static List<Point> XmlDeSerialization()
        {
            FileStream stream = new FileStream("data.xml", FileMode.Open, FileAccess.Read);
            List<Point> p = new List<Point>();
            XmlSerializer serialiser = new XmlSerializer(p.GetType());

            p = (List<Point>)serialiser.Deserialize(stream);
            stream.Close();

            return p;
        }

        private static void XmlSerialization(List<Point> points)
        {
            FileStream stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write);

            XmlSerializer serializer = new XmlSerializer(points.GetType());
            serializer.Serialize(stream, points);

            stream.Close();
        }

        private static Point BinaryDeSerialization()
        {
            FileStream stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read);

            BinaryFormatter format = new BinaryFormatter();
            Point p = (Point)format.Deserialize(stream);

            stream.Close();
            return p;
        }

        private static void BinarySerialization(Point p1)
        {
            FileStream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write);

            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, p1);

            stream.Close();
        }
    }

    [Serializable]
    public class Point
    {
        public int x;
        public int y;
        public string label;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {}
        public void Print()
        {
            Console.WriteLine("label - {0}\nX = {1}\nY = {2}", label, x, y);
        }
    }

}
