SELECT
	*
	--"typeID", "attributeID", "valueInt", "valueFloat", "description", "displayName"
FROM
	"dgmTypeAttributes"
	JOIN "dgmAttributeTypes" USING ("attributeID")
WHERE
	"published" = TRUE
    AND
	--"typeID" = 22474 -- Damnation
	--"typeID" = 24698 -- Drake
	--"typeID" = 28850 -- Ark
	--"typeID" = 28844 -- Rhea
	--"typeID" = 17480 -- Procurer
    "typeID" = 29984 -- Tengu
;