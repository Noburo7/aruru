CREATE TABLE t_course(
  course_id INTEGER PRIMARY KEY,
  track_id INTEGER,
  track_type_id INTEGER,
  distance INTEGER,
  FOREIGN KEY(track_id) REFERENCES t_track(track_id),
  FOREIGN KEY(track_type_id) REFERENCES t_track_type(type_id)
);
