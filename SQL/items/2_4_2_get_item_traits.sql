SELECT
	*
    --"bonus", "bonusText"
FROM
	"invTraits"
    --JOIN "eveUnits" USING ("unitID")
WHERE
    --"skillID" > 0
	--AND
	"typeID" = 47818 -- 'Unstable Large Armor Plate Mutaplasmid'
	--"typeID" = 45587 -- 'Legion Defensive - Augmented Plating'
    --"typeID" = 45590 -- 'Tengu Defensive - Supplemental Screening'
    --"typeID" = 45593 -- 'Proteus Defensive - Augmented Plating'
    --"typeID" = 45596 -- 'Loki Defensive - Augmented Durability'
	--"typeID" = 45595 -- 'Loki Defensive - Covert Reconfiguration'
	--"typeID" = 45597 -- 'Loki Defensive - Adaptive Defense Node'
;