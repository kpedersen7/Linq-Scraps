<Query Kind="Statements" />

string[] cars = {"forte","civic","accord","mustang","focus"};

//var shortCarNames = from car in cars
//					where car.Length == 5
//					select car;
					
//	shortCarNames.Dump();


var longCarNames = cars.Where(car => car.Length > 5);

longCarNames.Dump();