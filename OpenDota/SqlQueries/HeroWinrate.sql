SELECT 
    h.id,
    COUNT(*) AS matches,
    SUM(CASE WHEN ((m.radiant_win = TRUE) AND (pm.player_slot < 128)) OR ((m.radiant_win = FALSE) AND (pm.player_slot >= 128)) THEN 1 ELSE 0 END) AS wins
FROM heroes h
LEFT JOIN public_player_matches pm
    ON h.id = pm.hero_id
LEFT JOIN public_matches m
    ON pm.match_id = m.match_id
WHERE m.start_time BETWEEN {0} AND {1}
GROUP BY h.id