create table convenio (
id_convenio number(10) primary KEY,
cnpj varchar2(14) unique not null,
nome_fantasia varchar2(100) not null,
registro_ans varchar2(20)
);

create table especialidade(
id_especialidade number(10) primary key,
nome_espec varchar2(60) unique not null,
descricao varchar2(255)
);

create table medico(
id_medico number(10) primary key,
nome_completo varchar2(150) not null,
crm varchar2(20) unique not null,
uf_crm varchar2(2) not null,
id_especialidade number(10) references especialidade(id_especialidade)
);

create table paciente(
id_paciente number(15) primary key,
nome_completo varchar2(150) not null,
cpf varchar2(11) unique not null,
data_nascimento date not null,
telefone varchar2(15),
numero_carteira varchar2(50),
id_convenio number(10) references convenio(id_convenio)
);

create table prontuario(
id_prontuario number(20) primary key,
data_registro timestamp not null,
anamnese clob not null,
prescricao clob,
id_paciente number(15) references paciente(id_paciente), 
id_consulta number(15) references consulta(id_consulta)
);

create table consulta(
id_consulta number(15) primary key,
data_hora timestamp not null,
status varchar2(20) not null,
observacoes varchar2(500),
id_paciente number(15) references paciente(id_paciente),
id_medico number(10) references medico(id_medico) 
);

create table disponibilidade(
id_disponibilidade number(10) primary key,
dia_semana number(1) not null,
hora_inicio varchar2(5) not null,
hora_fim varchar2(5) not null,
id_medico number(10) references medico(id_medico) 
);