SELECT
	"typeID", "typeName", "groupID"
FROM
	"dgmTypeAttributes"
    JOIN "invTypes" USING ("typeID")
WHERE
	"attributeID" = 2746 -- "resistanceMultiplier"
	--"attributeID" = 271 -- 'shieldEmDamageResonance'
    --"attributeID" = 267 -- 'armorEmDamageResonance'
    --"attributeID" = 974 -- 'hullEmDamageResonance'
    --"attributeID" = 984 -- 'emDamageResistanceBonus'
	--"attributeID" = 146 -- 'shieldCapacityMultiplier'
    --"attributeID" = 148 -- 'armorHPMultiplier'
    --"attributeID" = 150 -- 'structureHPMultiplier'
    --"attributeID" = 1159 -- 'armorHPBonusAdd'
	--"attributeID" = 72 -- 'capacityBonus'
    --"attributeID" = 337 -- 'Shield Capacity Bonus', 'Autogenerated skill attribute, shieldCapacityBonus'
    --"attributeID" = 335 -- 'Armor Hitpoint Bonus', 'Autogenerated skill attribute, armorHpBonus'
    --"attributeID" = 327 -- 'Hitpoint Bonus', 'Autogenerated skill attribute, hullHpBonus'
    --"attributeID" = 1138 -- 'drawback'
    --"attributeID" = 1208 -- 'overloadHardeningBonus'
    --"attributeID" = 2675 -- 'specialSubsystemHoldCapacity'
    --"attributeID" = 73 -- 'duration'

    AND "published" = TRUE
    --AND "groupID" NOT IN (25,26,27,28,30,31,90,100,101,237,324,358,365,380,419,420,463,485,513,540,541,543,544,547,639,640,641,659,830,831,832,833,834,883,893,894,898,900,902,906,920,941,963,1022,1201,1202,1283,1305,1404,1406,1527,1534,1538,1657)
ORDER BY
	"groupID", "typeID"
;