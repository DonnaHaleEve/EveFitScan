SELECT
	*
	--"attributeID", "valueInt", "valueFloat", "description", "displayName"
FROM
	"dgmTypeAttributes"
	JOIN "dgmAttributeTypes" USING ("attributeID")
WHERE
    "typeID" = 24698 -- Drake
	--"typeID" = 28844 -- Rhea
	--"typeID" = 2048 -- Damage Control II
	--"typeID" = 2281 -- Adaptive Invulnerability Field II
    --"typeID" = 4348 -- Pithum B-Type Adaptive Invulnerability Field
	AND
	"published" = TRUE
;