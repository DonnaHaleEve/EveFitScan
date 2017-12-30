SELECT
	*
FROM
	"dgmEffects"
	JOIN "dgmTypeEffects" USING ("effectID")
    JOIN "invTypes" USING ("typeID")
WHERE
	"typeName" = 'Drake'
	--"typeID" = 24698 -- Drake
	--"typeID" = 28844 -- Rhea
	--"typeID" = 2048 -- Damage Control II
	--"typeID" = 2281 -- Adaptive Invulnerability Field II
    --"typeID" = 4348 -- Pithum B-Type Adaptive Invulnerability Field
;