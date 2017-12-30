SELECT
	*
FROM
	"invMarketGroups"
WHERE
	"marketGroupName" = 'Ships'
	AND
	"parentGroupID" IS NULL
;