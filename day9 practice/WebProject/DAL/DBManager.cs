namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public class DBConnect
{
    private static MySqlConnection con = null;
    private static string conString="server=192.168.10.150;port=3306;user=dac17; password=welcome;database=dac17";
    public DBConnect(){
        con = new MySqlConnection();
        con.ConnectionString = conString;
    }
    public List<Race> getAll(){
        List<Race> r_arr = new List<Race>();
        string query = "select * from races";
        MySqlCommand cmd = new MySqlCommand(query, con);
        try{
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                r_arr.Add(new ( int.Parse(reader["id"].ToString()), 
                                reader["event"].ToString(), 
                                int.Parse(reader["winner_id"].ToString())));
            }
        }catch(Exception e){
            Console.WriteLine("Error: "+e.Message);
        }
        return r_arr;
    }
    public Boolean insertRace(int id, string r_event, int winnerID){
        string query = "insert into races values (@id, @event, @winner_id)";
        MySqlCommand cmd = new MySqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.Parameters.AddWithValue("@event", r_event);
        cmd.Parameters.AddWithValue("@winner_id", winnerID);
        try{
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }catch(Exception e){
            Console.WriteLine("Error: "+e.Message);
            return false;
        }
    }

    public Boolean updateRace(int id, string r_event, int winnerID){
        string query = "update races set event=@event, winner_id=@winner_id where id=@id";
        MySqlCommand cmd = new MySqlCommand(query, con);
        cmd.Parameters.AddWithValue("@id",id);
        cmd.Parameters.AddWithValue("@event", r_event);
        cmd.Parameters.AddWithValue("@winner_id", winnerID);
        try{
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }catch(Exception e){
            Console.WriteLine("Error: "+e.Message);
            return false;
        }
    }
}
