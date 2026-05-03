# DatingApp - C# Desktop Application

Një platformë desktop e ndërtuar me **C#** dhe **Windows Forms** që mundëson lidhjen e përdoruesve bazuar në preferencat e tyre gjeografike dhe gjinore. Ky projekt përdor një arkitekturë të lehtë me skedarë **JSON** për menaxhimin e të dhënave.

## Veçoritë Kryesore

*   **Sistemi i Regjistrimit & Login:** Ruajtja e sigurt e të dhënave të përdoruesit në një databazë lokale JSON.
*   **Filtrimi Inteligjent (Matching):** Shfaqja automatike e profileve që përputhen me qytetin dhe gjininë që kërkoni.
*   **Menaxhimi i Profilit:** Mundësi për të ndryshuar të dhënat personale, biografinë dhe foton e profilit.
*   **Ndërfaqe Interaktive:** Përdorimi i kontrolleve dinamike për lundrim të thjeshtë mes faqeve.

## Teknologjitë e Përdorura

*   **Gjuha:** C# (.NET Framework/Core)
*   **UI:** Windows Forms (WinForms)
*   **Databaza:** JSON (përmes `Newtonsoft.Json` për serializim)
*   **IDE:** Visual Studio 2022

## ?Instalimi dhe Përdorimi

1.  **Klononi projektin:**
    ```bash
    git clone https://github.com/eridrekaj/DatingApp.git
    ```
2.  **Hapni projektin:** Hapni skedarin `.sln` në Visual Studio.
3.  **Instaloni varësitë:** Sigurohuni që të keni paketën `Newtonsoft.Json` të instaluar via NuGet.
4.  **Ekzekutoni:** Shtypni `F5` për të nisur aplikacionin.

## Struktura e Skedarëve

*   `Form.cs`: Logjika kryesore e ndërfaqes dhe navigimit.
*   `User.cs`: Modeli i të dhënave për përdoruesit.
  * `Universiteti.cs': Modeli i të dhënave për universitetet.
*   `users_db.json`: Skedari ku ruhen të gjitha informacionet në format tekstual.
  * `universities_db.json`: Skedari ku ruhen të gjitha universitetet në format tekstual.

## Autori

**Ervis Drekaj** - *Web & Software Developer*
*   GitHub: [@eridrekaj](https://github.com/eridrekaj)
*   Website: [eridrekaj.com](https://eridrekaj.com)
*   Location: Albania ????