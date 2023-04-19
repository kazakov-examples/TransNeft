
using System;
using System.Collections.Generic;

using MySqlConnector;


struct Point_t  {
    public int ID;                 //INT PRIMARY KEY,
    public string Counter;         //COUNTER CHAR(20),   
    public DateTime CounterDate;   //COUNTER_DATE DATE,
    public string TransCurr;       //TRANSCURR CHAR(20),
    public string TransVolt;       //TRANSVOLT CHAR(20),

    //Constructor
    public Point_t(int ID,
                 string Counter,
                 DateTime CounterDate,
                 string TransCurr,
                 string TransVolt)  {
        this.ID = ID;
        this.Counter = Counter;
        this.CounterDate = CounterDate;
        this.TransCurr = TransCurr;
        this.TransVolt = TransVolt;         
    }

    //Print
    public void Print()  {
        Console.Write("{0,-2}  ",   ID);          
        Console.Write("{0,-10}  ",  Counter);     
        Console.Write("{0,-6}  ",   CounterDate.ToString("d"));    
        Console.Write("{0,-4}  ",   TransCurr);       
        Console.Write("{0,-4}  ",   TransVolt); 
        
        Console.WriteLine();  
    }
}


static class PointsAPI  {   
    
    //-----------Objects-----------
    

    //-----------Methods-----------   

    //Add point
    public static bool Add( MySqlConnection conn, 
                            int ID,
                            string Counter,
                            string CounterDate,
                            string TransCurr,
                            string TransVolt)  {
        MySqlCommand cmd;
        string SqlExpr;
        int n = 0;

        string IDstr;

        IDstr      ="'" + ID.ToString() + "'";
        Counter    ="'" + Counter     + "'";
        CounterDate="'" + CounterDate + "'";
        TransCurr  ="'" + TransCurr   + "'";
        TransVolt  ="'" + TransVolt   + "'";

        SqlExpr  = "";
        SqlExpr += "insert into Points (ID, COUNTER, COUNTER_DATE, TRANSCURR, TRANSVOLT)";
        SqlExpr += "values(";
        SqlExpr += IDstr + ",";
        SqlExpr += Counter + ",";
        SqlExpr += CounterDate + ",";
        SqlExpr += TransCurr + ",";
        SqlExpr += TransVolt;
        SqlExpr += ");";
        
        cmd = new MySqlCommand(SqlExpr, conn);
        n = cmd.ExecuteNonQuery();
        
        if(n==1)  {
            return true;
        }
        else  {
            return false;
        }    
    }


    //Read points by year
    public static List<Point_t> ReadByYear(MySqlConnection conn, int Year, string Compare)  {
        MySqlCommand cmd;
        MySqlDataReader reader;
        string SqlExpr;

        List<Point_t> Points = new List<Point_t>();
                
        SqlExpr  = "";
        SqlExpr += "select * from Points ";
        SqlExpr += "where(extract(year from Points.COUNTER_DATE)"+Compare+"'"+Year.ToString()+"');";
        
        cmd = new MySqlCommand(SqlExpr, conn);
        reader = cmd.ExecuteReader();

        //Read rows
        if(reader.HasRows)  {
            while(reader.Read())  {
                Point_t Rd = new Point_t();

                Rd.ID = reader.GetInt32(0);
                Rd.Counter = reader.GetString(1);
                Rd.CounterDate = reader.GetDateTime(2);
                Rd.TransCurr = reader.GetString(3);
                Rd.TransVolt = reader.GetString(4);
            
                Points.Add(Rd);
            }
        }
        
        return Points;
    }
    


}

        
                        
           