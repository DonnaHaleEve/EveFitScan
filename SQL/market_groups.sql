--SELECT
--	*
--FROM
--	"invMarketGroups"
--WHERE
--	"marketGroupID" = 4;



SELECT
	"marketGroupID"
FROM
	"invMarketGroups"
WHERE
	"marketGroupName" = 'Ships'
    AND
    "parentGroupID" IS NULL
;