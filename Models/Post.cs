using System;
using System.ComponentModel.DataAnnotations; // stringlength
using System.ComponentModel.DataAnnotations.Schema;//Column
using System.Collections.Generic;
namespace Blog.Models
{
public class Post
{
public int Id {get; set;}

[StringLength(100)] //dataanotation define o tipo de dado como varchar  e determina um limite de caractere para  100
public string Titulo { get; set; }

[Column(TypeName ="TEXT")]//dataanotation.Schema converte o campo longtext criado pela migrations para Text
public string Texto { get; set; }// aqui é carregado o testo que sera listado coma opção de comentario
public DateTime Data {get; set;}
public ICollection<Comentario> Comentarios {get; set;}
}
}