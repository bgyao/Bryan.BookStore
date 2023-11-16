using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bryan.BookStore.Books.Dtos;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(28)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; }

    [Required]
    public float Price { get; set; }
}
