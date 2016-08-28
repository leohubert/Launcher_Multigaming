$.notify.addStyle("metro", {
    html:
        "<div>" +
            "<div class='image' data-notify-html='image'/>" +
            "<div class='text-wrapper'>" +
                "<div class='title' data-notify-html='title'/>" +
                "<div class='text' data-notify-html='text'/>" +
            "</div>" +
        "</div>",
    classes: {
        default: {
            "color": "#fafafa !important",
            "background-color": "#3bafda",
            "border": "1px solid #3bafda"
        },
        error: {
            "color": "#fafafa !important",
            "background-color": "#ef5350",
            "border": "1px solid #ef5350"
        },
        custom: {
            "color": "#fafafa !important",
            "background-color": "#5fbeaa",
            "border": "1px solid #5fbeaa"
        },
        success: {
            "color": "#fafafa !important",
            "background-color": "#81c868",
            "border": "1px solid #33b86c"
        },
        info: {
            "color": "#fafafa !important",
            "background-color": "#3ddcf7",
            "border": "1px solid #3ddcf7"
        },
        warning: {
            "color": "#fafafa !important",
            "background-color": "#ffbd4a",
            "border": "1px solid #ffd740"
        },
        black: {
            "color": "#fafafa !important",
            "background-color": "#4c5667",
            "border": "1px solid #212121"
        },
        white: {
            "background-color": "#e6eaed",
            "border": "1px solid #ddd"
        }
    }
});