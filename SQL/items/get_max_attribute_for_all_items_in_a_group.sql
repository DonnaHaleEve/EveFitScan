SELECT
	"typeID", "typeName", "attributeID", "valueInt", "valueFloat"
	--"valueFloat"
FROM
	"dgmTypeAttributes"
    JOIN "invTypes" USING ("typeID")
WHERE
	--"marketGroupID" = 605 -- small shield extenders
	"marketGroupID" = 606 -- medium shield extenders
	AND
	"attributeID" = 72 -- "Shield Hitpoint Bonus"
ORDER BY
	"valueFloat" DESC