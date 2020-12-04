CREATE TABLE t_remark(
  race_id INTEGER,
  remark TEXT,
  FOREIGN KEY(race_id) REFERENCES t_race(race_id)
);
