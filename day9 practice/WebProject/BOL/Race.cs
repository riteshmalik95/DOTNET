namespace BOL;

public class Race
{
    private int id;
    private string r_event;
    private int winnerID;
    public Race(){
        this.id = 0;
        this.r_event = null;
        this.winnerID = 0;
    }
        public Race(int id, string r_event, int winnerID){
        this.id = id;
        this.r_event = r_event;
        this.winnerID = winnerID;
    }
    public int Race_ID{
        get{return this.id;}
        set{this.id = value;}
    }
    public string Event_Name{
        get{return this.r_event;}
        set{this.r_event = value;}
    }
    public int Race_WinnerID{
        get{return this.winnerID;}
        set{this.winnerID = value;}
    }

}
