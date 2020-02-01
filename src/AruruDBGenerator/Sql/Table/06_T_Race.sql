CREATE TABLE t_race(
  race_id INTEGER PRIMARY KEY AUTOINCREMENT,
  race_date TEXT,
  track INTEGER,
  race_number INTEGER,
  track_type INTEGER
  distance INTEGER,
  race_class INTEGER,
  track_condition INTEGER,
  handicap_flag INTEGER,
  female_flag INTEGER,
  age_flag INTEGER,
  FOREIGN KEY (track) REFERENCES t_track(track_id),
  FOREIGN KEY (track_type) REFERENCES t_track_type(type_id),
  FOREIGN KEY (race_class) REFERENCES t_race_class(class_id),
  FOREIGN KEY (track_condition) REFERENCES t_track_condition(condition_id)
);
