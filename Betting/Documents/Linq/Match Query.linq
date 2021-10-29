<Query Kind="Expression">
  <Connection>
    <ID>9716e247-55c8-4d01-a2db-19d519eac093</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Anhnt-CA-Betting-Data</Database>
  </Connection>
</Query>

var teamview =
(from match in Matches
 join team1 in Teams on match.HTeam equals team1.TeamName
 join team2 in Teams on match.GTeam equals team2.TeamName
 join season in Seasons on match.SeasonId equals season.SeasonId
 where season.SeasonId=="UEFAEURO2020"
 orderby match.MatchYear descending, match.MatchNumber ascending
 select new
 {
	 match.MatchId,
	 match.MatchNumber,
	 match.DateMatch,
	 match.TimeMatch,
	 match.MatchYear,
	 match.SeasonId,
	 season.SeasonName,
	 match.Round,
	 match.Stage,
	 match.SubStage,
	 match.HTeam,
	 HTeamCode = team1.TeamCode,
	 match.HGoal,
	 match.GGoal,
	 match.GTeam,
	 GTeamCode = team2.TeamCode,
	 match.WinNote,
	 match.Stadium,
	 match.Referee,
	 match.Visistors

 })