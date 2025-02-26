SELECT *
FROM Houses
INNER JOIN ParksHouses ON Houses.Id = ParksHouses.House_id
INNER JOIN Parks ON ParksHouses.Park_id = Parks.Id

INNER JOIN HouseReservations ON Houses.Id = HouseReservations.House_id
INNER JOIN Reservations ON HouseReservations.Reservation_id = Reservations.Id

WHERE Parks.Location = 'Oostende' 
AND MaxPersons = 3 
AND Active = 'true'
AND '2025/01/03' NOT BETWEEN Reservations.Startdate AND Reservations.Enddate
AND '2025/03/03' NOT BETWEEN Reservations.Startdate AND Reservations.Enddate;