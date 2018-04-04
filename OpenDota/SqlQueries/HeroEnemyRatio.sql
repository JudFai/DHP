SELECT 
    h.id, 
    pm_adv.hero_id, 
    COUNT(*) as matches, 
    SUM(CASE WHEN ((m.radiant_win = TRUE) AND (pm.player_slot < 128)) OR ((m.radiant_win = FALSE) AND (pm.player_slot >= 128)) THEN 1 ELSE 0 END) AS wins 
FROM heroes h 
JOIN public_player_matches pm 
    ON h.id = pm.hero_id 
JOIN public_matches m 
    ON pm.match_id = m.match_id 
JOIN public_player_matches pm_adv 
    ON m.match_id = pm_adv.match_id 
WHERE 
    (m.start_time BETWEEN {0} AND {1}) AND 
    (((pm.player_slot >= 128) AND (pm_adv.player_slot < 128)) OR ((pm.player_slot < 128) AND (pm_adv.player_slot >= 128))) AND
	(pm_adv.hero_id > 0)
GROUP BY h.id, pm_adv.hero_id 
HAVING h.id <> pm_adv.hero_id