console.log("Search JS Loaded");

document.addEventListener("DOMContentLoaded", function () {

    const searchBox =
        document.getElementById("searchBox");

    const searchBtn =
        document.getElementById("searchBtn");

    const searchResults =
        document.getElementById("searchResults");

    async function loadSuggestions(keyword) {

        if (!keyword) {

            searchResults.innerHTML = "";
            return;
        }

        try {

            const response =
                await fetch(`/User/Product/Search?keyword=${encodeURIComponent(keyword)}`);

            const products =
                await response.json();

            let html = "";

            if (products.length === 0) {

                html = `
                    <div class="alert alert-warning">
                        No Products Found
                    </div>
                `;
            }
            else {

                products.slice(0, 5).forEach(product => {

                    html += `
        <div class="card p-3 mb-2 shadow-sm search-card"
             onclick="window.location.href='/User/Product/Details/${product.id}'"
             style="cursor:pointer;">

            <h5>${product.name}</h5>

            <p class="text-success fw-bold">
                ₹ ${product.price}
            </p>

            <small>
                ${product.description}
            </small>

        </div>
    `;
                });

                html += `

                    <div class="text-center mt-3">

                        <button type="button"
                                class="btn btn-search"
                                id="viewAllBtn">

                            View All Results

                        </button>

                    </div>

                `;
            }

            searchResults.innerHTML = html;

            const viewAllBtn =
                document.getElementById("viewAllBtn");

            if (viewAllBtn) {

                viewAllBtn.addEventListener("click", goToSearchPage);
            }
        }
        catch (error) {

            console.error(error);
        }
    }

    function goToSearchPage() {

        const keyword =
            searchBox.value.trim();

        if (!keyword)
            return;

        window.location.href =
            `/User/Product/SearchResults?keyword=${encodeURIComponent(keyword)}`;
    }

    searchBox.addEventListener("keyup", function () {

        loadSuggestions(this.value.trim());

    });

    searchBtn.addEventListener("click", function () {

        goToSearchPage();

    });

    searchBox.addEventListener("keydown", function (e) {

        if (e.key === "Enter") {

            e.preventDefault();

            goToSearchPage();

        }

    });

});