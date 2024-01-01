namespace BLL;
using DAL;
using BOL;
public class RacesManager
{
    private DBConnect db;
    public RacesManager(){
        db = new DBConnect();
    }
    public List<Race> getAllRaces(){
        return db.getAll();
    }
    public Boolean insert(int id, string r_event, int winnerID){
        return db.insertRace(id, r_event, winnerID);
    }
}
