SELECT
	*
FROM
	"invTraits"
	JOIN "eveUnits" USING ("unitID")
WHERE
	--"typeID" = 24698 -- Drake
	--"typeID" = 28844 -- Rhea
    "typeID" = 12731 -- Bustard
;