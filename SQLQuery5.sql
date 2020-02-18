SELECT f.Destination, COUNT(*) as frequncy FROM dbo.Flights f
GROUP BY f.Destination
ORDER BY frequncy DESC