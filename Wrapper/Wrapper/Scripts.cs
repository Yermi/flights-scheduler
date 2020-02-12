namespace Wrapper
{
    public class Scripts
    {
        public static readonly string ShowScheduledFlightsTab = $@"
                            (function func() {{
                                var b = document.getElementById('linkScheduledFlights');
                                b.click();
                                return $('.popupBg').css('display')
                            }})()";

        public static readonly string WaitPopupColaps = $@"
                            (function func() {{
                                return $('.popupBg').css('display')
                            }})()";

        public static readonly string CollectCountries = $@"
                        (() => {{
                            var countries = []
                            var listItems = $('#ui-id-6 li');
                            listItems.each(function(idx, li) {{
                                var product = $(li);
                                var country = product[0].getElementsByTagName('span')[0].textContent;
                                countries.push(country)
                            }});
                            return countries;
                         }})()";

        public static readonly string CollectCities = $@"
                        (() => {{
                            var countries = []
                            var listItems = $('#ui-id-7 li');
                            listItems.each(function(idx, li) {{
                                var product = $(li);
                                var country = product[0].getElementsByTagName('span')[0].textContent;
                                countries.push(country)
                            }});
                            return countries;
                         }})()";
        public static string searchForDateScript(string p_date) => $@"                
                $('#ctl00_from').val('{p_date}')
                $('#ctl00_to').val('{p_date}')
                $('#ctl00_A3').click();
            ";

        public static readonly string ExpandTable = @"
                IAA.FlightsBoard.CurrentPagerView = false;
                IAA.FlightsBoard.CurrentItemsLimit = -1;
                IAA.FlightsBoard.RefreshData()
            ";

        public static readonly string CountRows = @"
            (() => {
                var rowCount = $('#board3 tr').length;
                return rowCount;
            })()
            ";

        public static readonly string CollectFlightsData = @"(() => {
                var list = [];
                var table = document.getElementById('board3');
                for (var i = 1, row; row = table.rows[i]; i++)
                {
                    let airline = row.getElementsByTagName('a')[0] ? row.getElementsByTagName('a')[0].href : null;
                    let img = airline ? row.getElementsByTagName('a')[0].getElementsByTagName('img')[0].src : null;
                    let filghtId = row.cells[1].innerText;
                    let destination = row.cells[2].innerText;
                    let date = row.cells[3].innerText;
                    let dayOfWeek = row.cells[4].innerText;
                    let terminal = row.cells[5].innerText;
                    let obj = { Carrier: airline, ImagePath: img, FlightID: filghtId, Source: 'Tel Aviv', Destination: destination, DepartureTime: date, DayOfWeek: dayOfWeek, Terminal: terminal};
                    list.push(obj);
                }
                return list;
                })()";
    }
}