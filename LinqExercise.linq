<Query Kind="Statements">
  <Connection>
    <ID>72e0ab3f-dcc9-4d94-a2e7-a96428df690e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

//LINQ EXERCISE
EmployeeSkills
Skills
//1. Show all skills requiring a ticket and which employees have those skills.
from x in Skills
orderby x.Description
where x.RequiresTicket
select new{
			Description = x.Description,
			Employees = (from y in EmployeeSkills
							where y.SkillID == x.SkillID
							select new{
								Name = y.Employee.FirstName + " " + y.Employee.LastName,
								Level = y.Level,
								YearsExperience = y.YearsOfExperience
								})
			}
//2. List all skills, alphabetically, showing only the description of the skill.
from x in Skills
orderby x.Description
select new {
	Description = x.Description
}

//3.List all the skills for which we do not have any qualfied employees.
from x in Skills
where x.EmployeeSkills.Count == 0
select new {
	Description = x.Description
}

//4. From the shifts scheduled for NAIT's placement contract, show the number of employees needed for each day (ordered by day-of-week).
//Bonus: display the name of the day of week (first day being Monday).			
from x in Shifts
where x.PlacementContractID == 4
group x by x.DayOfWeek into temp
select new {
		Day = (from y in temp select y.DayOfWeek).Max(),
		NumberEmployees = temp.Sum(y => y.NumberOfEmployees)
	}
	
//5. List all the employees with the most years of experience.
var MostExperienced = (from x in EmployeeSkills
orderby x.YearsOfExperience descending
select new {
	Name = x.Employee.FirstName + " " + x.Employee.LastName
}).Take(8);
MostExperienced.Dump();
