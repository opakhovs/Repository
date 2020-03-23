< !--Global site tag(gtag.js) - Google Analytics-- >
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-161429060-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
        gtag('js', new Date());
      
        gtag('config', 'UA-161429060-1');
</script>

function handleOutboundLinkClicks(event) {
    ga('send', 'event', {
        eventCategory: 'Outbound Link',
        eventAction: 'click',
        eventLabel: event.target.href
    });
}