select Houses.Street, Parks.Location
FROM Houses
INNER JOIN ParksHouses ON Houses.Id = ParksHouses.House_id
INNER JOIN Parks ON ParksHouses.Park_id = Parks.Id
WHERE Houses.Street = 'boterbloemstraat';