module.exports = app => {
    app.get('/api/project/GetProject', (req, res) => {
        var data = require('../json/carta.json');
        res.json(data);
    })

}