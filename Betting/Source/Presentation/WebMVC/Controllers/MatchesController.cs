﻿using Application.Features.Matches.Commands;
using Application.Features.Matches.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Abstractions;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //public class MatchesController : BaseController<MatchesController>
    public class MatchesController : Controller
    {
        private ISender _mediator;
        public MatchesController(ISender mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }       

        public async Task<IActionResult> ViewAllMatch()
        {
            var matchQuery = await _mediator.Send(new GetMatchesDetail());
            //ReUse model from Apllication Layer
            //Manual Mapping from matches to MatchViewModel
            //GetMatchesDetail : IRequest<IEnumerable<MatchesDetail>>
            //Manual Mapping IEnumerable<MatchesDetail> =>IEnumerable<MatchViewModel>
            //MatchViewModel matchesvm = new MatchViewModel();
            List<MatchViewModel> retList = new List<MatchViewModel>();            
            foreach (var item in matchQuery)
            {
                MatchViewModel matchesvm = new MatchViewModel();
                #region ManualMapping
                matchesvm.MatchId = item.MatchId;
                matchesvm.MatchNumber = item.MatchNumber;
                matchesvm.DateMatch = item.DateMatch;
                matchesvm.TimeMatch = item.TimeMatch;
                matchesvm.MatchYear = item.MatchYear;
                matchesvm.SeasonId = item.SeasonId;
                matchesvm.SeasonName = item.SeasonName;
                matchesvm.Round = item.Round;
                matchesvm.Stage = item.Stage;
                matchesvm.SubStage = item.SubStage;
                matchesvm.HTeam = item.HTeam;
                matchesvm.HGoal = item.HGoal;
                matchesvm.HTeamCode = item.HTeamCode;
                matchesvm.GGoal = item.GGoal;
                matchesvm.GTeam = item.GTeam;
                matchesvm.GTeamCode = item.GTeamCode;
                matchesvm.WinNote = item.WinNote;
                matchesvm.Stadium = item.Stadium;
                matchesvm.Referee = item.Referee;
                matchesvm.Visistors = item.Visistors;
                #endregion
                retList.Add(matchesvm);
            }
            retList = retList.OrderByDescending(e => e.MatchYear).ThenBy(m => m.MatchNumber).ToList();
            return View(retList);            
        }
        public async Task<IActionResult> ViewMatchByTeam(string teamname)
        {
            var matchQuery = new GetMatchesDetailByTeamName(teamname);
            var result = await _mediator.Send(matchQuery);
            List<MatchViewModel> resList = new List<MatchViewModel>();

            foreach (var item in result)
            {
                MatchViewModel matchesvm = new MatchViewModel();
                #region ManualMapping
                matchesvm.MatchId = item.MatchId;
                matchesvm.MatchNumber = item.MatchNumber;
                matchesvm.DateMatch = item.DateMatch;
                matchesvm.TimeMatch = item.TimeMatch;
                matchesvm.MatchYear = item.MatchYear;
                matchesvm.SeasonId = item.SeasonId;
                matchesvm.SeasonName = item.SeasonName;
                matchesvm.Round = item.Round;
                matchesvm.Stage = item.Stage;
                matchesvm.SubStage = item.SubStage;
                matchesvm.HTeam = item.HTeam;
                matchesvm.HGoal = item.HGoal;
                matchesvm.HTeamCode = item.HTeamCode;
                matchesvm.GGoal = item.GGoal;
                matchesvm.GTeam = item.GTeam;
                matchesvm.GTeamCode = item.GTeamCode;
                matchesvm.WinNote = item.WinNote;
                matchesvm.Stadium = item.Stadium;
                matchesvm.Referee = item.Referee;
                matchesvm.Visistors = item.Visistors;
                #endregion
                resList.Add(matchesvm);
            }

            return View(resList);
        }
        public async Task<IActionResult> ViewMatchBySeason(string seasonId)
        {
            var matchQuery = new GetMatchesDetailBySeason(seasonId);
            var result = await _mediator.Send(matchQuery);
            List<MatchViewModel> resList = new List<MatchViewModel>();
            foreach (var item in result)
            {
                MatchViewModel matchesvm = new MatchViewModel();
                #region ManualMapping
                matchesvm.MatchId = item.MatchId;
                matchesvm.MatchNumber = item.MatchNumber;
                matchesvm.DateMatch = item.DateMatch;
                matchesvm.TimeMatch = item.TimeMatch;
                matchesvm.MatchYear = item.MatchYear;
                matchesvm.SeasonId = item.SeasonId;
                matchesvm.SeasonName = item.SeasonName;
                matchesvm.Round = item.Round;
                matchesvm.Stage = item.Stage;
                matchesvm.SubStage = item.SubStage;
                matchesvm.HTeam = item.HTeam;
                matchesvm.HGoal = item.HGoal;
                matchesvm.HTeamCode = item.HTeamCode;
                matchesvm.GGoal = item.GGoal;
                matchesvm.GTeam = item.GTeam;
                matchesvm.GTeamCode = item.GTeamCode;
                matchesvm.WinNote = item.WinNote;
                matchesvm.Stadium = item.Stadium;
                matchesvm.Referee = item.Referee;
                matchesvm.Visistors = item.Visistors;
                #endregion
                resList.Add(matchesvm);
            }

            return View(resList);
        }
        public async Task<IActionResult> ViewHistory(string hteam, string gteam)
        {
            var matchQuery = new GetHistoryMatchTwoTeam(hteam,gteam);
            var result = await _mediator.Send(matchQuery);
            List<MatchViewModel> resList = new List<MatchViewModel>();
            foreach (var item in result)
            {
                MatchViewModel matchesvm = new MatchViewModel();
                #region ManualMapping
                matchesvm.MatchId = item.MatchId;
                matchesvm.MatchNumber = item.MatchNumber;
                matchesvm.DateMatch = item.DateMatch;
                matchesvm.TimeMatch = item.TimeMatch;
                matchesvm.MatchYear = item.MatchYear;
                matchesvm.SeasonId = item.SeasonId;
                matchesvm.SeasonName = item.SeasonName;
                matchesvm.Round = item.Round;
                matchesvm.Stage = item.Stage;
                matchesvm.SubStage = item.SubStage;
                matchesvm.HTeam = item.HTeam;
                matchesvm.HGoal = item.HGoal;
                matchesvm.HTeamCode = item.HTeamCode;
                matchesvm.GGoal = item.GGoal;
                matchesvm.GTeam = item.GTeam;
                matchesvm.GTeamCode = item.GTeamCode;
                matchesvm.WinNote = item.WinNote;
                matchesvm.Stadium = item.Stadium;
                matchesvm.Referee = item.Referee;
                matchesvm.Visistors = item.Visistors;
                #endregion
                resList.Add(matchesvm);
            }

            return View(resList);
        }       
        // GET: Update/Edit/stringmatchid
        [HttpGet] 
        public async Task<IActionResult> UpdateMatchScore(string matchId)
        {
            var matchQuery = new GetMatchesDetailByStrId(matchId);

            var response = await _mediator.Send(matchQuery);
            MatchViewModel matchesvm = new MatchViewModel();
            #region ManualMapping
                matchesvm.MatchId = response.MatchId;
                matchesvm.MatchNumber = response.MatchNumber;
                matchesvm.DateMatch = response.DateMatch;
                matchesvm.TimeMatch = response.TimeMatch;
                matchesvm.MatchYear = response.MatchYear;
                matchesvm.SeasonId = response.SeasonId;
                matchesvm.SeasonName = response.SeasonName;
                matchesvm.Round = response.Round;
                matchesvm.Stage = response.Stage;
                matchesvm.SubStage = response.SubStage;
                matchesvm.HTeam = response.HTeam;
                matchesvm.HGoal = response.HGoal;
                matchesvm.HTeamCode = response.HTeamCode;
                matchesvm.GGoal = response.GGoal;
                matchesvm.GTeam = response.GTeam;
                matchesvm.GTeamCode = response.GTeamCode;
                matchesvm.WinNote = response.WinNote;
                matchesvm.Stadium = response.Stadium;
                matchesvm.Referee = response.Referee;
                matchesvm.Visistors = response.Visistors;
            #endregion         

            return View(matchesvm);
            //return View();
        }
        public IActionResult TestView()
        {
            return View();
        }
        public IActionResult FifaView()
        {
            return View();
        }
        public IActionResult EsportView()
        {
            return View();
        }
    }
}
