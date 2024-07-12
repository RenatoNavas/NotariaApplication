-- Crear tablas sin dependencias
CREATE TABLE tipo_especialidad (
  id_tipo_especialidad SERIAL PRIMARY KEY,
  descripcion_tipo_especialidad varchar(240)
);

CREATE TABLE membership_groups (
  groupID SERIAL PRIMARY KEY,
  name varchar(20),
  description text,
  allowSignup int,
  needsApproval int
);

CREATE TABLE membership_grouppermissions (
  permissionID SERIAL PRIMARY KEY,
  groupID int,
  tableName varchar(100),
  allowInsert int,
  allowView int NOT NULL DEFAULT 0,
  allowEdit int NOT NULL DEFAULT 0,
  allowDelete int NOT NULL DEFAULT 0,
  FOREIGN KEY (groupID) REFERENCES membership_groups (groupID)
);

CREATE TABLE membership_userpermissions (
  permissionID SERIAL PRIMARY KEY,
  memberID varchar(20) NOT NULL,
  tableName varchar(100),
  allowInsert int,
  allowView int NOT NULL DEFAULT 0,
  allowEdit int NOT NULL DEFAULT 0,
  allowDelete int NOT NULL DEFAULT 0
);

-- Crear tablas con dependencias
CREATE TABLE especialidad (
  id_especialidad SERIAL PRIMARY KEY,
  nombre_especialidad varchar(240),
  tipo_especialidad bigint,
  FOREIGN KEY (tipo_especialidad) REFERENCES tipo_especialidad (id_tipo_especialidad)
);

CREATE TABLE paciente (
  id_paciente SERIAL PRIMARY KEY,
  apellidos_paciente varchar(40),
  nombres_paciente varchar(40),
  nombre_apellido_paciente varchar(255),
  cedula_paciente varchar(20),
  genero_paciente varchar(15),
  edad_paciente int,
  fecha_paciente date,
  etnia_paciente varchar(40),
  sangre_paciente varchar(40),
  profesion_paciente varchar(140),
  religion_paciente varchar(120),
  foto_paciente varchar(240),
  observaciones_paciente varchar(40)
);

CREATE TABLE medicos (
  id_medicos SERIAL PRIMARY KEY,
  id_especialidad bigint,
  nombres_medicos varchar(40),
  apellidos_medicos varchar(40),
  FOREIGN KEY (id_especialidad) REFERENCES especialidad (id_especialidad)
);

CREATE TABLE historia (
  id_historia SERIAL PRIMARY KEY,
  id_paciente bigint,
  codigo_historia varchar(40),
  enfermedades_historia varchar(240),
  antecedentes_personales_historia varchar(240),
  antecedentes_familiares_historia varchar(240),
  motivo_historia varchar(240),
  fecha_historia varchar(40),
  documento_historia varchar(40),
  FOREIGN KEY (id_paciente) REFERENCES paciente (id_paciente)
);

CREATE TABLE aps (
  id_aps SERIAL PRIMARY KEY,
  id_paciente bigint,
  id_especialidad bigint,
  id_medico bigint,
  fecha_aps date,
  motivo_aps varchar(240),
  ras_aps varchar(240),
  examen_fisico_aps varchar(240),
  apoyo_diagnostico_aps varchar(240),
  plan_diagnostico_aps varchar(240),
  plan_terapeutico_aps varchar(240),
  plan_educativo_aps varchar(240),
  plan_especializado_aps varchar(240),
  archivo_aps varchar(240),
  observaciones_aps varchar(240),
  FOREIGN KEY (id_paciente) REFERENCES paciente (id_paciente),
  FOREIGN KEY (id_especialidad) REFERENCES especialidad (id_especialidad),
  FOREIGN KEY (id_medico) REFERENCES medicos (id_medicos)
);

-- Crear tablas restantes
CREATE TABLE membership_userrecords (
  recID SERIAL PRIMARY KEY,
  tableName varchar(100),
  pkValue varchar(255),
  memberID varchar(20),
  dateAdded bigint,
  dateUpdated bigint,
  groupID int,
  FOREIGN KEY (groupID) REFERENCES membership_groups (groupID)
);

CREATE TABLE membership_users (
  memberID varchar(20) PRIMARY KEY,
  passMD5 varchar(40),
  email varchar(100),
  signupDate date,
  groupID int,
  isBanned int,
  isApproved int,
  custom1 text,
  custom2 text,
  custom3 text,
  custom4 text,
  comments text,
  pass_reset_key varchar(100),
  pass_reset_expiry int,
  FOREIGN KEY (groupID) REFERENCES membership_groups (groupID)
);

-- Índices para tablas volcadas
CREATE INDEX aps_id_paciente_index ON aps (id_paciente);
CREATE INDEX aps_id_especialidad_index ON aps (id_especialidad);
CREATE INDEX aps_id_medico_index ON aps (id_medico);
CREATE INDEX especialidad_tipo_especialidad_index ON especialidad (tipo_especialidad);
CREATE INDEX historia_id_paciente_index ON historia (id_paciente);
CREATE INDEX medicos_id_especialidad_index ON medicos (id_especialidad);
CREATE INDEX membership_grouppermissions_groupID_index ON membership_grouppermissions (groupID);
CREATE INDEX membership_userpermissions_memberID_index ON membership_userpermissions (memberID);
CREATE INDEX membership_userrecords_tableName_index ON membership_userrecords (tableName);
CREATE INDEX membership_userrecords_memberID_index ON membership_userrecords (memberID);
CREATE INDEX membership_userrecords_groupID_index ON membership_userrecords (groupID);
CREATE INDEX membership_users_groupID_index ON membership_users (groupID);
CREATE INDEX paciente_id_paciente_index ON paciente (id_paciente);
CREATE INDEX tipo_especialidad_id_tipo_especialidad_index ON tipo_especialidad (id_tipo_especialidad);


-- Volcado de datos para la tabla `tipo_especialidad`
INSERT INTO tipo_especialidad (id_tipo_especialidad, descripcion_tipo_especialidad)
VALUES
(1, 'MATERNO INFANTIL'),
(2, 'MEDICINAS INTERNAS');

-- Volcado de datos para la tabla `especialidad`
INSERT INTO especialidad (id_especialidad, nombre_especialidad, tipo_especialidad)
VALUES
(1, 'PEDIATRIA', 1),
(2, 'GINECOLOGIA', 1),
(3, 'OBSTETRICIA', 1),
(4, 'MEDICINA FAMILIAR', 2);

-- Volcado de datos para la tabla `paciente`
INSERT INTO paciente (id_paciente, apellidos_paciente, nombres_paciente, nombre_apellido_paciente, cedula_paciente, genero_paciente, edad_paciente, fecha_paciente, etnia_paciente, sangre_paciente, profesion_paciente, religion_paciente, foto_paciente, observaciones_paciente)
VALUES
(1, 'HERRERA FREIRE', 'JUAN CARLOS', 'HERRERA FREIRE JUAN CARLOS', '1729340192', 'MASCULINO', 32, NULL, 'MESTIZO', 'ORH+', NULL, 'CRISTIANO', NULL, NULL),
(2, 'CALDERON GONZALEZ', 'VIVIANA BEATRIZ', 'CALDERON GONZALEZ VIVIANA BEATRIZ', '1603749182', 'FEMENINO', 23, NULL, 'MESTIZA', 'ORH+', 'QD', 'CATOLICA', NULL, NULL);

-- Volcado de datos para la tabla `medicos`
INSERT INTO medicos (id_medicos, id_especialidad, nombres_medicos, apellidos_medicos)
VALUES
(1, 1, 'MARCO VINICIO', 'MORILLO SAENZ'),
(2, 1, 'ZAPATA GONZALEZ', 'MARIA ELENA');

-- Volcado de datos para la tabla `historia`
INSERT INTO historia (id_historia, id_paciente, codigo_historia, enfermedades_historia, antecedentes_personales_historia, antecedentes_familiares_historia, motivo_historia, fecha_historia, documento_historia)
VALUES
(1, 1, 'HC-MI-1793710192', 'NEURALGIA CRONICA, HIPERTENSION ARTERIAL', 'DOLORES DE CABEZA FRECUENTES', 'HIPERTENSION DE ABUELA PATERNA DIABETES ABUELA MATERNA', 'DOLORES DE CABEZA Y SANGRADO DE NARIZ FRECUENTES', NULL, NULL);

-- Volcado de datos para la tabla `aps`
INSERT INTO aps (id_aps, id_paciente, id_especialidad, id_medico, fecha_aps, motivo_aps, ras_aps, examen_fisico_aps, apoyo_diagnostico_aps, plan_diagnostico_aps, plan_terapeutico_aps, plan_educativo_aps, plan_especializado_aps, archivo_aps, observaciones_aps)
VALUES
(1, 1, NULL, 2, '2023-11-02', 'DOLORES DE CABEZA Y CEFALEAS FRECUENTES Y SANGRADO DE NARIZ', 'REVISION APARATOS Y SISTEMAS: CABEZA CUELLO TORAX ABDOMEN EXTREMIDADES PIEL', 'EXAMEN FISICO', 'APOYO DIAGNOSTICO', 'PLAN DIAGNOSTICO', 'PLAN TERAPEUTICO MEDICACION', 'PLAN EDUCATIVO PARA EL PACIENTE', 'PLAN ESPECIALIZADO SEGUN PATOLOGIA DEL PACIENTE', 'ARCHIVO DE RESPALDO DE LA HC Y/O DOCUMENTACION DEL PACIENTE.', 'OBSERVACIONES SI FUERA DEL CASO');

-- Volcado de datos para las tablas de membresía
INSERT INTO membership_grouppermissions (permissionID, groupID, tableName, allowInsert, allowView, allowEdit, allowDelete)
VALUES
(1, 2, 'tipo_especialidad', 1, 3, 3, 3),
(2, 2, 'especialidad', 1, 3, 3, 3),
(3, 2, 'paciente', 1, 3, 3, 3),
(4, 2, 'historia', 1, 3, 3, 3),
(5, 2, 'medicos', 1, 3, 3, 3),
(6, 2, 'aps', 1, 3, 3, 3);

INSERT INTO membership_groups (groupID, name, description, allowSignup, needsApproval)
VALUES
(1, 'anonymous', 'Anonymous group created automatically on 2023-11-23', 0, 0),
(2, 'Admins', 'Admin group created automatically on 2023-11-23', 0, 1);

INSERT INTO membership_userpermissions (permissionID, memberID, tableName, allowInsert, allowView, allowEdit, allowDelete)
VALUES
(1, 'admin', 'tipo_especialidad', 1, 3, 3, 3),
(2, 'admin', 'especialidad', 1, 3, 3, 3),
(3, 'admin', 'tipo_especialidad', 1, 3, 3, 3),
(4, 'admin', 'especialidad', 1, 3, 3, 3),
(5, 'admin', 'especialidad', 1, 3, 3, 3),
(6, 'admin', 'especialidad', 1, 3, 3, 3),
(7, 'admin', 'medicos', 1, 3, 3, 3),
(8, 'admin', 'medicos', 1, 3, 3, 3),
(9, 'admin', 'paciente', 1, 3, 3, 3),
(10, 'admin', 'historia', 1, 3, 3, 3),
(11, 'admin', 'aps', 1, 3, 3, 3),
(12, 'admin', 'tipo_especialidad', 1, 3, 3, 3);

INSERT INTO membership_userrecords (recID, tableName, pkValue, memberID, dateAdded, dateUpdated, groupID)
VALUES
(1, 'tipo_especialidad', '1', 'admin', 1637702022, 1637702022, 2),
(2, 'tipo_especialidad', '2', 'admin', 1637702022, 1637702022, 2),
(3, 'tipo_especialidad', '3', 'admin', 1637702022, 1637702022, 2),
(4, 'tipo_especialidad', '4', 'admin', 1637702022, 1637702022, 2),
(5, 'especialidad', '1', 'admin', 1637702022, 1637702022, 2),
(6, 'especialidad', '2', 'admin', 1637702022, 1637702022, 2),
(7, 'especialidad', '3', 'admin', 1637702022, 1637702022, 2),
(8, 'especialidad', '4', 'admin', 1637702022, 1637702022, 2),
(9, 'paciente', '1', 'admin', 1637702022, 1637702022, 2),
(10, 'historia', '1', 'admin', 1637702022, 1637702022, 2),
(11, 'medicos', '1', 'admin', 1637702022, 1637702022, 2),
(12, 'medicos', '2', 'admin', 1637702022, 1637702022, 2),
(13, 'aps', '1', 'admin', 1637702022, 1637702022, 2);

INSERT INTO membership_users (memberID, passMD5, email, signupDate, groupID, isBanned, isApproved, custom1, custom2, custom3, custom4, comments, pass_reset_key, pass_reset_expiry)
VALUES
('admin', '5f4dcc3b5aa765d61d8327deb882cf99', 'admin@example.com', '2023-11-23', 2, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- Volcado de datos para la tabla `aps`
INSERT INTO aps (
  id_aps,
  id_paciente,
  id_especialidad,
  id_medico,
  fecha_aps,
  motivo_aps,
  ras_aps,
  examen_fisico_aps,
  apoyo_diagnostico_aps,
  plan_diagnostico_aps,
  plan_terapeutico_aps,
  plan_educativo_aps,
  plan_especializado_aps,
  archivo_aps,
  observaciones_aps
) VALUES (
  1,
  1,
  NULL,
  2,
  '2023-11-02',
  'DOLORES DE CABEZA Y CEFALEAS FRECUENTES Y SANGRADO DE NARIZ',
  'REVISION APARATOS Y SISTEMAS: CABEZA CUELLO TORAX ABDOMEN EXTREMIDADES PIEL',
  'EXAMEN FISICO',
  'APOYO DIAGNOSTICO',
  'PLAN DIAGNOSTICO',
  'PLAN TERAPEUTICO MEDICACION',
  'PLAN EDUCATIVO PARA EL PACIENTE',
  'PLAN ESPECIALIZADO SEGUN PATOLOGIA DEL PACIENTE',
  'ARCHIVO DE RESPALDO DE LA HC Y/O DOCUMENTACION DEL PACIENTE.',
  'OBSERVACIONES SI FUERA DEL CASO'
);
