using System;
using System.Collections.Generic;

using MySqlConnector;


namespace _TransNeft {
    
    class Program {
        static void Main(string[] args) {
        
            //List of Points
            List<Point_t> Points = new List<Point_t>();

            //MySqlConnection
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost; uid=root; pwd=MySQL; Database=Points;";

            //Open connection
            try  {
                conn.Open();
                Console.WriteLine("------Conn opened-----");
            }
            catch(MySqlException ex)  {
                Console.WriteLine(ex.Message);
            }

            //Add point
            PointsAPI.Add(conn, 7, "HOT",  "2018-04-01", "IL", "VH");
            PointsAPI.Add(conn, 8, "COLD", "2018-04-02", "IH", "VL");
            PointsAPI.Add(conn, 9, "HOT",  "2018-04-04", "IL", "VH");

            //Read points
            Points = PointsAPI.ReadByYear(conn, 2018, "=");

            //Print points
            int i = 0;
            Point_t Rd;
            for(i=0; i<Points.Count; i++)  {
                Rd = Points[i];
                Rd.Print();           
            }

            //Close connection
            conn.Close();
            Console.WriteLine("------Conn closed------");     

            Console.WriteLine("Press any key..");
            Console.ReadLine();
        }
    }
}
