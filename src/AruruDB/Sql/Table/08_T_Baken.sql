CREATE TABLE t_baken(
  baken_id INTEGER PRIMARY KEY AUTOINCREMENT,
  race_id INTEGER,
  baken_type_id INTEGER,
  bet INTEGER,
  payout INTEGER,
  FOREIGN KEY(race_id) REFERENCES t_race(race_id),
  FOREIGN KEY(baken_type_id) REFERENCES t_baken_type(type_id)
);
