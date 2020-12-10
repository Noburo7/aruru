CREATE TABLE t_race(
  race_id INTEGER PRIMARY KEY AUTOINCREMENT,
  race_date TEXT,
  race_number INTEGER,
  race_name TEXT,
  track_id INTEGER,
  track_type_id INTEGER,
  distance INTEGER,
  race_class_id INTEGER,
  track_condition_id INTEGER,
  handicap_flag INTEGER,
  female_flag INTEGER,
  age_flag INTEGER,
  FOREIGN KEY (track_id) REFERENCES t_track(track_id),
  FOREIGN KEY (track_type_id) REFERENCES t_track_type(type_id),
  FOREIGN KEY (race_class_id) REFERENCES t_race_class(class_id),
  FOREIGN KEY (track_condition_id) REFERENCES t_track_condition(condition_id)
);
