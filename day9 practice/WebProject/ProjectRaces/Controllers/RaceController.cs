using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectRaces.Models;
using BLL;
using BOL;

namespace ProjectRaces.Controllers;

public class RaceController : Controller
{
    private readonly ILogger<RaceController> _logger;
    RacesManager rmgr = new RacesManager();

    public RaceController(ILogger<RaceController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AllRacesPage()
    {
        List<Race> r_arr = new List<Race>();
        r_arr = rmgr.getAllRaces();
        ViewData["Races"] = r_arr;
        return View();
    }
    public IActionResult Insert(int id, string r_event, int winnerID){
        Boolean res = rmgr.insert(id, r_event, winnerID);
        if(res)
            ViewData["InsertRace"] = "Data Inserted Successfully";
        else
            ViewData["InsertRace"] = "Data Insertion Unsuccessful";

        return View();
    }
}
