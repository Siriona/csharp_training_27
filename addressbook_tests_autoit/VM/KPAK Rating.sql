select * from organizations_e oe
join organizations o on o.entity_id=oe.entity_id 
join organization_list_orgs olo on olo.organization_id=o.ORGANIZATION_ID
join organization_list ol on ol.ORGANIZATION_LIST_ID=olo.organization_list_id
join ORGANIZATION_LIST_E ole on ole.ENTITY_ID=ol.entity_id
where oe.inn=6165120974 and ole.RATING_YEAR=2018

select * from plan_shortcoming ps
where ps.destination_id=<organization_id>;