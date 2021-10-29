select * from Matches


select Matches.SeasonId,Matches.Round,Matches.Stage,Matches.SubStage,Matches.HTeam,Matches.HGoal,Matches.GGoal,
	(case
		when HGoal=GGoal then 1
		when HGoal>GGoal then 3
		else  0
	end) as score,
	Matches.GTeam	
from Matches where Matches.Stage ='Group'