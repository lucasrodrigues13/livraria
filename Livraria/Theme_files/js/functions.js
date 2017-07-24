var LoadBookList = function () {
    var idgeral = 0;
    $.getJSON("http://localhost:1212/api/book", function (data) {
        $.each(data, function (key, val) {
            var name = val.Name;
            var edition = val.Edition;
            var description = val.Description;
            var isbn = val.ISBN;
            var id = val.Id;
            var authorName = val.Authors[0].Name;
            var authorBirth = val.Authors[0].BirthDate;
            var namePublisher = val.Publisher.Name;
            var addressPublisher = val.Publisher.Address;
            var zipCodePublisher = val.Publisher.ZipCode;

            $('#booksOnTheTable')
                .append('<tr>'
                + '<td align= "center" > <a class="btn btn-default editar"><em class="fa fa-pencil"></em></a> <a class="btn btn-danger remover"><em class="fa fa-trash "></em></a></td >'
                + '<td class="hidden-xs tdIsbn">' + isbn + '</td>'
                + '<td class="hidden-xs tdName">' + name + '</td >'
                + '<td class="hidden-xs tdDescription">' + description + '</td >'
                + '<td class="tdAuthor">' + authorName + '</td > '
                + '<td class="tdEdition">' + edition + '</td > '
                + '<td class="tdPublisher">' + namePublisher + '</td > '
                + '<td class="tdId" style="display:none;">' + id + '</td ></tr > '
                + '<td class="tdAuthorBirth" style="display:none;">' + authorBirth + '</td ></tr > '
                + '<td class="tdAddressPublisher" style="display:none;">' + addressPublisher + '</td ></tr > '
                + '<td class="tdZipCodePublisher" style="display:none;">' + zipCodePublisher + '</td ></tr > ');
        });
    });
}