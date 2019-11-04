// Gist forked from Vardner/dropdown 
// @ https://gist.github.com/Vardner/db361aa4b8097012126447fe4fce0f72
// because of the CSS attribute selectors on data items, and the
// abstract jquery functions like toggleClass and slideToggle that I
// purposefully avoid. Just so I don't forget they exist even though I avoid
// them on purpose.

'use strict';

function enableDropdowns () {
  const dropdownElements = $('[data-dropdown=toggle]');

  if (dropdownElements.length) {
    dropdownElements.click(showDropdown)
  }

  function showDropdown (e) {
    const shadow = $('#shadow');
    const dropdown = $(this);
    const dropdownContent = dropdown.find('[data-dropdown=target]');

    if (e.target.closest('[data-dropdown=target]')) {
      return;
    }

    shadow.toggleClass('active');
    dropdownContent.slideToggle(500);

    shadow.click(
        () => {
          shadow.removeClass('active');
          dropdownContent.removeClass('active');
          dropdownContent.slideUp(500);
        }
    )
  }
}

enableDropdowns();