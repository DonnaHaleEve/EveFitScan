SELECT
--	*
	"typeID", "typeName"
FROM
	"dgmTypeEffects"
    JOIN "invTypes" USING ("typeID")
WHERE
	"effectID" IN (11,12,13,2663,3772)
;