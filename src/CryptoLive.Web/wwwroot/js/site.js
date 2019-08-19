var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2
});

const tradeWs = new WebSocket('wss://ws.coincap.io/trades/binance');

tradeWs.onerror = function (msg) {
    console.log(msg);
}

tradeWs.onmessage = function (msg) {
    console.log(msg.data);
};

$(document).ready(function () {
    $('#coins').DataTable({
        "order": [],
        "pageLength": 25
    });

    $("#loader").hide(50);
    $("#coins").show(0);

});

window.updateData = function (data) {

    var jsonObject = JSON.parse(data);

    if (jsonObject.quote !== undefined) {

        var coin = 'COIN_' + jsonObject.quote;
        var coin_data = jsonObject;

        var _coinTable = $('#coins');
        var row = _coinTable.find("tr#" + coin);
        price = _coinTable.find("tr#" + coin + " .price");
        change = _coinTable.find("tr#" + coin + " .change");
        volume = _coinTable.find("tr#" + coin + " .volume");
        capital = _coinTable.find("tr#" + coin + " .market_capital");
        supply = _coinTable.find("tr#" + coin + " .supply");
        _price = formatter.format(coin_data.price);
        previous_price = $(price).data('usd');
        _class = coin_data.direction === 'buy' ? 'increment' : 'decrement';
        if (coin_data.direction === 'buy') {
            $(price).html(_price).removeClass().addClass(_class + ' price').data("usd", _price);
        } else {
            $(price).html(_price).removeClass().addClass(_class + ' price').data("usd", _price);
        }
        $(volume).html(formatter.format(coin_data.volume));
        $(capital).html(formatter.format(coin_data.price_usd));
        $(supply).html(new Intl.NumberFormat('en-US').format(coin_data.price_usd));

        if (_price !== previous_price) {
            _class = previous_price < _price ? 'increment' : 'decrement';
            $(row).addClass(_class);
            setTimeout(function () {
                $(row).removeClass('increment decrement');
            }, 500);
        }
    }
};