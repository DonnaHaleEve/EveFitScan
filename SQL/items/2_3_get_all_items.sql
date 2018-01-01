SELECT
	*
FROM
	"invTypes"
	JOIN
	"dgmTypeEffects" USING ("typeID")
WHERE
	"published" = TRUE
    AND
	--"effectID" IN (11,12,13,2663,3772)
	--"effectID" IN (11,12,13,2663)
    "effectID" = 3772
;