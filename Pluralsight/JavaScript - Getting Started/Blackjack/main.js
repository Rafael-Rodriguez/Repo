import Engine from './engine.js'


window.onload = function() {

    console.log("onload:  Creating new engine")
    var engine = new Engine();

    console.log("onload:  engine.run")
    engine.run();
}

