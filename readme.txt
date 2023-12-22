NS.STMS

Scaffold-DbContext "Host=localhost;Port=5432;Database=ns_stms;Username=postgres;Password=mysecretpassword; Trust Server Certificate=true;" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Context -UseDatabaseNames -Force

CREATE TABLE public.t_user
(
    id integer NOT NULL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	surname VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	date_of_birth DATE NOT NULL,
    t_county_id integer NOT NULL REFERENCES t_county (id),
	image_base64 VARCHAR,
	
    created_at timestamp without time zone NOT NULL,
    created_by integer NOT NULL,
    updated_at timestamp without time zone,
    updated_by integer,
    is_deleted boolean NOT NULL
)

CREATE SEQUENCE IF NOT EXISTS public.t_user_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1
    OWNED BY t_user.id;


ALTER TABLE t_user ALTER COLUMN id SET DEFAULT nextval('t_user_id_seq'::regclass);

{
  "Name": "Enes",
  "Surname": "Şentürk",
  "Email": "enesenturk61@gmail.com",
  "DateOfBirth": "1996-09-04T00:00:00.000Z",
  "GradeId": 10,
  "SchoolName": "Akçaabat Anadolu Lisesi",
  "CountyId": 898
}