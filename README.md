# TRexRunnerGame

## Opis
T. Rex Runner Game to desktopowa gra polegająca na omijaniu przeszkód biegnącym dinozaurem i zdobyciu jak największego wyniku. W grze wraz z postępem rośnie poziom trudności.

## Zastosowane wzorce projektowe

1. `Bridge` - oddzielenie abstrakcji podziału jednostek od ich impementacji umożliwiający ich zmiany niezależnie od siebie
2. `Builder` - oddzielenie konstrukcji graficznego komponentu o złożonej strukturze od jego reprezentacji. Ten sam proces konstrukcji jest używany do tworzenia grafiki dla różnych typów jednostek.
3. `Factory` - tworzenie komponentu obsługującego fizykę różnych typów jednostek bez określania ich konkretnych klas
4. `Singleton` - zapewnienie, że główna postać (dinozaur) będzie miała jedną globalnie dostępną instancję
5. `State` - w zależności od stanu gry dinozaur przyjmuje różną prezentację graficzną
6. `Dependency Injection` - usunięcie bezpośredniej zależności pomiędzy komponentami gry
7. `MVC` - podział gry na 3 komponenty: widok - klasy View i komponenty graficzne odpowiedzialne za wyświetlanie, model - klasy obsługujące fizykę zawierają rdzeń działania gry oraz kontroler - główna klasa Game obsługująca wejście i komunikująca się z modelem i widokiem
8. `Facade` - interfejs widoku udostępnia prosty interfejs dla złożonej klasy (Windows Forms)
9. `Strategy` - w zależności od osiągniętego wyniku zmiana poziomu trudności
10. `Mediator` - obsługuje zmianę stanu gry wywołując odpowiednie metody

## Diagram klas

**Class diagram:**<br>
![cd](docs/ClassDiagram.jpg)<br>