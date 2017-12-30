SELECT
	*
FROM
	"invTypes"
WHERE
	"marketGroupID" = 72 -- ships > frigates > standard frigates > amarr
    AND
    published = TRUE
;