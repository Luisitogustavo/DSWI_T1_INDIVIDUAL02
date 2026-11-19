
"use strict";

document.addEventListener("DOMContentLoaded", () => {

    const reduceMotion = window.matchMedia(
        "(prefers-reduced-motion: reduce)"
    ).matches;

    // 1. MENÚ RESPONSIVE
    const menuButton = document.querySelector(".mobile-nav-toggle");
    const menu = document.querySelector("#nexusNavigation");

    menuButton?.addEventListener("click", () => {
        const abierto = menu.classList.toggle("open");

        menuButton.setAttribute("aria-expanded", String(abierto));
        menuButton.setAttribute(
            "aria-label",
            abierto ? "Cerrar navegación" : "Abrir navegación"
        );
    });

    // 2. ILUMINACIÓN DINÁMICA DEL CRISTAL
    if (!reduceMotion) {
        document.querySelectorAll(".glass-surface").forEach(elemento => {
            elemento.addEventListener("pointermove", event => {
                const rect = elemento.getBoundingClientRect();

                const x = event.clientX - rect.left;
                const y = event.clientY - rect.top;

                elemento.style.setProperty("--mx", `${x}px`);
                elemento.style.setProperty("--my", `${y}px`);
            });
        });
    }

    // 3. ANIMACIÓN DE COMPONENTES
    const elementos = document.querySelectorAll(
        ".hero-panel, .metric-card, .module-card, .section-heading"
    );

    if (!reduceMotion && "IntersectionObserver" in window) {
        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) return;

                entry.target.classList.add("reveal");
                observer.unobserve(entry.target);
            });
        }, { threshold: 0.08 });

        elementos.forEach(elemento => observer.observe(elemento));
    }

    // 4. CONTADORES DEL DASHBOARD
    document.querySelectorAll("[data-count]").forEach(elemento => {
        const total = Number(elemento.dataset.count);

        if (!Number.isFinite(total) || reduceMotion) return;

        const duracion = 750;
        let inicio;

        function animar(timestamp) {
            inicio ??= timestamp;

            const progreso = Math.min(
                (timestamp - inicio) / duracion, 1
            );

            const suavizado = 1 - Math.pow(1 - progreso, 3);

            elemento.textContent = Math.round(
                total * suavizado
            ).toLocaleString("es-PE");

            if (progreso < 1) requestAnimationFrame(animar);
        }

        requestAnimationFrame(animar);
    });

    // 5. BUSCADOR INSTANTÁNEO EN CLIENTES Y PEDIDOS
    const normalizar = texto =>
        texto.normalize("NFD")
            .replace(/[\u0300-\u036f]/g, "")
            .toLowerCase()
            .trim();

    document.querySelectorAll("table.table").forEach(tabla => {
        const cuerpo = tabla.querySelector("tbody");
        if (!cuerpo) return;

        const buscador = document.createElement("input");

        buscador.type = "search";
        buscador.className = "table-search";
        buscador.placeholder = "Buscar registros...";
        buscador.setAttribute("aria-label", "Buscar registros");

        tabla.parentElement.insertBefore(buscador, tabla);

        buscador.addEventListener("input", () => {
            const consulta = normalizar(buscador.value);

            cuerpo.querySelectorAll("tr").forEach(fila => {
                fila.hidden = !normalizar(
                    fila.textContent
                ).includes(consulta);
            });
        });
    });

    // 6. EVITAR ENVÍOS DUPLICADOS
    document.querySelectorAll("form[method='post']").forEach(formulario => {
        formulario.addEventListener("submit", evento => {
            if (formulario.dataset.enviando === "true") {
                evento.preventDefault();
                return;
            }

            if (!formulario.checkValidity()) return;

            formulario.dataset.enviando = "true";

            const boton = formulario.querySelector(
                "button[type='submit']"
            );

            if (boton) {
                boton.textContent = "Procesando...";
                boton.setAttribute("aria-disabled", "true");
            }
        });
    });

    // 7. MICROINTERACCIONES
    document.querySelectorAll(".module-card").forEach(tarjeta => {
        tarjeta.addEventListener("focus", () => {
            tarjeta.style.borderColor = "rgba(220,239,255,.5)";
        });

        tarjeta.addEventListener("blur", () => {
            tarjeta.style.borderColor = "";
        });
    });

});
