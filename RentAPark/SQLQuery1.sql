SELECT Reservations.Id, Startdate, Enddate, Customer_id, Parks.Name FROM Reservations
INNER JOIN HouseReservations ON Reservations.Id = HouseReservations.Reservation_id
INNER JOIN ParksHouses ON HouseReservations.House_id = ParksHouses.House_id
INNER JOIN Parks ON ParksHouses.Park_id = Parks.Id
WHERE Parks.Name = 'Sail Park' AND ('2022/05/11' BETWEEN Startdate and Enddate OR '2019-12-31' BETWEEN Startdate and Enddate);