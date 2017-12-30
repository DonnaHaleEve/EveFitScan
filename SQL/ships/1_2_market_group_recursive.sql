SELECT
	*
FROM
	"invMarketGroups"
WHERE
	--"parentGroupID" = 4 -- base market group for ships
	--"parentGroupID" = 1361 -- frigates
	"parentGroupID" = 5 -- standard frigates
;