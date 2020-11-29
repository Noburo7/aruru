CREATE TABLE t_baken(
  baken_id INTEGER PRIMARY KEY AUTOINCREMENT,
  race INTEGER,
  baken_type INTEGER,
  bet INTEGER,
  payout INTEGER,
  FOREIGN KEY(race) REFERENCES t_race(race_id),
  FOREIGN KEY(baken_type) REFERENCES t_baken_type(type_id)
);
